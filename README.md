#HostsUpdater#

Updates the local [hosts file](http://en.wikipedia.org/wiki/Hosts_file).

> Note: HostsUpdater just works on Windows for now but there is a plan to support other platforms using Mono.

##Usage##

Suppose that you want to assign `127.0.0.1` address to `myserver` name.

Then open a command prompt with administrator privileges and run the following command in that path of `HostsUpdater.exe`.

    HostsUpdater 127.0.0.1 myserver

If there is already a record for `127.0.0.1` then HostsUpdater updates it, otherwise it adds a new record to the hosts file.

Now you can ping `myserver`.

    ping myserver

##Requirements##
- .NET Framework 4.0
