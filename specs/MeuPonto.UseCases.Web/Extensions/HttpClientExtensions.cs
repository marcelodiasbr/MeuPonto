using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace MeuPonto.Helpers;

public static class HttpClientExtensions
{
    public static Task<HttpResponseMessage> SendAsync(
        this HttpClient client,
        IHtmlFormElement form,
        IHtmlElement submitButton)
    {
        return client.SendAsync(form, submitButton, new Dictionary<string, string>());
    }

    public static Task<HttpResponseMessage> SendAsync(
        this HttpClient client,
        IHtmlFormElement form,
        IEnumerable<KeyValuePair<string, string>> formValues)
    {
        var submitElement = form.QuerySelectorAll("[type=submit]").Single();
        var submitButton = submitElement as IHtmlElement;

        return client.SendAsync(form, submitButton, formValues);
    }

    public static Task<HttpResponseMessage> SendAsync(
        this HttpClient client,
        IHtmlFormElement form,
        IHtmlElement submitButton,
        IEnumerable<KeyValuePair<string, string>> formValues)
    {
        foreach (var kvp in formValues)
        {
            var element = form[kvp.Key] as IHtmlInputElement;
            element.Value = kvp.Value;
        }
        
        if (form.IsValid())
        {
            var submit = form.GetSubmission(submitButton);
            var target = (Uri)submit.Target;
            if (submitButton.HasAttribute("formaction"))
            {
                var formaction = submitButton.GetAttribute("formaction");
                target = new Uri(formaction, UriKind.Relative);
            }
            var submission = new HttpRequestMessage(new HttpMethod(submit.Method.ToString()), target)
            {
                Content = new StreamContent(submit.Body)
            };

            foreach (var header in submit.Headers)
            {
                submission.Headers.TryAddWithoutValidation(header.Key, header.Value);
                submission.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            return client.SendAsync(submission);
        }
        else
        {
            throw new Exception("Formul�rio n�o est� v�lido");
        }
    }
}
