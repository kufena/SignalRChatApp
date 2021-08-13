## A simple Chat app using SignalR

After playing with websockets and finding they're quite hard (ie similar to standard TCP sockets but less rounded)
I've made a simple chat app using SignalR.

The server runs as usual in ASP.NET and the client is a simple command line client.

I'm not sure the types are right yet.  Perhaps there's some generics we can use to make them
better typed.  That's next, I suppose.

Most of this code comes from

    https://docs.microsoft.com/en-us/aspnet/core/signalr/introduction?view=aspnetcore-5.0

which is a good introduction to hubs and clients.