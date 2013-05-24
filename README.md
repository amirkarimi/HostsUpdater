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

##Stupid Solution##

###Having a personal server##

You have a personal server at home? Then you want it to be accessible from work or home?

As I know you have these solutions to access the server:

- use its local static IP address (Ex. `192.168.1.10`) when you're at home and use its public static IP address when you're at work.
- configure your modem to route the internal requests for your public IP address to the local one then you can use the public static IP address from either work or home. (Of course your modem should be capable of that.)
- or you can use **HostsUpdater**. (The stupid solution!)

To use HostsUpdater for this scenario you can create two `.bat` files. One for remote access and another for local access. You can put shortcuts of these files on your desktop and simply run them on appropriate conditions. Then use `myserver` whenever you need to put your server address.

####Local access file####

    HostsUpdater 192.168.1.10 myserver

> Please note that you should use the full path of HostsUpdater and use your server local address instead of **192.168.1.10**.

####Remote access file####

    HostsUpdater #.#.#.# myserver

> Put your public static IP address instead of **#.#.#.#**.


##Requirements##
- .NET Framework 4.0
