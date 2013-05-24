namespace HostsUpdater
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class FileUpdater
    {
        private readonly string fileName;
        private IList<string> lines;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileUpdater"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public FileUpdater(string fileName)
        {
            this.fileName = fileName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileUpdater"/> class.
        /// </summary>
        public FileUpdater()
        {
            this.fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts");
        }

        /// <summary>
        /// Reads this instance.
        /// </summary>
        private void Read()
        {
            this.lines = File.ReadAllLines(this.fileName).ToList();
        }

        /// <summary>
        /// Writes this instance.
        /// </summary>
        private void Write()
        {
            File.WriteAllLines(this.fileName, this.lines);
        }

        /// <summary>
        /// Updates the host.
        /// </summary>
        /// <param name="ip">The IP address.</param>
        /// <param name="name">The name.</param>
        public void UpdateHostRecord(string ip, string name)
        {
            this.Read();

            name = name.Trim();
            ip = ip.Trim();

            bool updated = false;
            int count = this.lines.Count;
            for (int i = 0; i < count; i++)
            {
                var line = this.lines[i];

                if (line.StartsWith("#"))
                {
                    // Comment
                    continue;
                }

                var splited = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (splited.Length < 2)
                {
                    // Incorrect format
                    continue;
                }

                if (splited[1].Trim().Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    // Update
                    this.lines[i] = this.GetLine(ip, splited[1]);
                    updated = true;
                    break;
                }
            }

            if (!updated)
            {
                // Insert
                this.lines.Add(this.GetLine(ip, name));
            }

            this.Write();
        }

        /// <summary>
        /// Gets the line.
        /// </summary>
        /// <param name="ip">The IP.</param>
        /// <param name="splited">The name.</param>
        /// <returns></returns>
        private string GetLine(string ip, string name)
        {
            return string.Format("{0}\t\t\t{1}", ip, name);
        }
    }
}
