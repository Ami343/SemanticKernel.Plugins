using Microsoft.SemanticKernel.Events;

namespace Common.Hooks;

public static class KernelPostFunctionHook
{
    public static void Handle(object? sender, FunctionInvokedEventArgs e)
    {
        Console.WriteLine($"Post-Hook Function: {e.FunctionView.Name}");
    }
}