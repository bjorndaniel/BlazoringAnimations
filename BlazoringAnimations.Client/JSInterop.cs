using Microsoft.AspNetCore.Blazor.Browser.Interop;

namespace BlazoringAnimations.Client
{
    public class JSInterop
    {
        public static string InitAnimations()
        {
            return RegisteredFunction.Invoke<string>(
                "BlazoringAnimations.Client.JsInterop.InitAnimations");

        }
        public static string CalculateAnimation()
        {
            return RegisteredFunction.Invoke<string>(
                "BlazoringAnimations.Client.JsInterop.CalculateAnimation");
        }
        public static string ResetAnimation()
        {
            return RegisteredFunction.Invoke<string>(
                "BlazoringAnimations.Client.JsInterop.ResetAnimation");
        }
        public static string Alert(string message)
        {
            return RegisteredFunction.Invoke<string>(
                "BlazoringAnimations.Client.JsInterop.Alert", message);
        }
    }
}
