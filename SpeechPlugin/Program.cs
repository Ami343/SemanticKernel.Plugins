using AzureAI.Community.Microsoft.Semantic.Kernel.Speech;
using Common.Configuration;
using Common.Helpers;
using Microsoft.CognitiveServices.Speech;
using Microsoft.SemanticKernel;

Console.WriteLine("Speech plugin - process started");

// Get app configurations
var azureOpenAiConfiguration = ConfigurationHelper.GetConfiguration<AzureOpenAiSettings>();
var speechServiceConfiguration = ConfigurationHelper.GetConfiguration<SpeechServiceSettings>();

// Create speech to text service
var speechToText = new SpeechToText(speechServiceConfiguration.ApiKey, speechServiceConfiguration.Region);
speechToText.SpeechConfig.SetProperty(PropertyId.Speech_SegmentationSilenceTimeoutMs, "2000");
speechToText.Build();

// Initialize kernel instance 
var kernel = KernelBuilderHelper.CreateKernel(
    azureOpenAiConfiguration.DeploymentName,
    azureOpenAiConfiguration.Endpoint,
    azureOpenAiConfiguration.ApiKey);

var speechToTextDic = kernel.ImportSkill(
    new AzureAI.Community.Microsoft.Semantic.Kernel.Speech.Plugin.SpeechPlugin(speechToText),
    nameof(AzureAI.Community.Microsoft.Semantic.Kernel.Speech.Plugin.SpeechPlugin));

var skFunction = kernel.CreateSemanticFunction("Process the input {{$input}}");

var result = await kernel.RunAsync(speechToTextDic["ListenSpeechVoice"], skFunction);

Console.WriteLine(result);

Console.WriteLine("Process finished");

Console.Read();