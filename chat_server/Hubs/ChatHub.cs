using chat_server.Models;
using Microsoft.AspNetCore.SignalR;

namespace chat_server.Hubs;

public class ChatHub : Hub<IChatClient>
{
    public async Task JoinChat(UserConnection connection)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, connection.ChatRoomName);
        await Clients
            .Group(connection.ChatRoomName)
            .ReceiveMessage("Admin", $"{connection.UserName} was added");
    }
}

public interface IChatClient
{
    public Task ReceiveMessage(string userName, string message);
}