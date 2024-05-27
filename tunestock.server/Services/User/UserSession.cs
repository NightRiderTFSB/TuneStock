using tunestock.api.dto;

namespace tunestock.server.Services.User;

public class UserSession
{
    public core.entities.User CurrentUser { get; set; }

    public event Action OnChange;

    public void SetSession(core.entities.User user)
    {
        CurrentUser = user;
        NotifySessionChanged();
    }

    private void NotifySessionChanged() => OnChange?.Invoke();
}