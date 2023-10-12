using Common.Configuration;
using Common.Helpers;
using Microsoft.SemanticKernel.Orchestration;
using SemanticFunctions.Extensions;

var azureOpenAiConfig = ConfigurationHelper.GetConfiguration<AzureOpenAiSettings>();

var kernel = KernelBuilderHelper.CreateKernel(azureOpenAiConfig);

var skill = kernel.ImportHRAssistantSkill();

var context = new ContextVariables();
context.Set("input", "I'm 24 years old and I'm interested in technology. I love to explore new trends and learn.");

var result = await kernel.RunAsync(context, skill["Role"]);

Console.WriteLine(result);
