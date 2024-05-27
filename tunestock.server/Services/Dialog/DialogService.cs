using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

public class DialogService
{
    private TaskCompletionSource<bool>? _dialogTaskCompletionSource;

    public event Action<RenderFragment>? OnShow;
    public event Action? OnClose;

    public Task<bool> ShowDialog(RenderFragment content)
    {
        _dialogTaskCompletionSource = new TaskCompletionSource<bool>();

        OnShow?.Invoke(content);

        return _dialogTaskCompletionSource.Task;
    }

    public void CloseDialog(bool result)
    {
        if (_dialogTaskCompletionSource != null)
        {
            _dialogTaskCompletionSource.SetResult(result);
            _dialogTaskCompletionSource = null;
            OnClose?.Invoke();
        }
    }
}