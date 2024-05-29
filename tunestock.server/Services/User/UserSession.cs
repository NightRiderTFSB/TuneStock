using tunestock.api.dto;

namespace tunestock.server.Services.User;

public class UserSession {
    public core.entities.User CurrentUser { get; set; } = new core.entities.User {
        Admin = false
    };

    public event Action OnChange;

    public void SetSession(core.entities.User user)
    {
        CurrentUser = user;
        NotifySessionChanged();
    }

    private void NotifySessionChanged() => OnChange?.Invoke();
}