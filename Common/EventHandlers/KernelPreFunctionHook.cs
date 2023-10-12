using Microsoft.SemanticKernel.Events;

namespace Common.Hooks;

public static class KernelPreFunctionHook
{
    public static void Handle(object? sender, FunctionInvokingEventArgs e)
    {
        Console.WriteLine($"Pre-Hook Function: {e.FunctionView.Name}");
    }
}