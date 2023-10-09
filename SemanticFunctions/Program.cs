using Common.Configuration;
using Common.Helpers;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Orchestration;

var azureOpenAiConfig = ConfigurationHelper.GetConfiguration<AzureOpenAiSettings>();

var kernel = KernelBuilderHelper.CreateKernel(azureOpenAiConfig);

var skillsDir = Path.Combine(Directory.GetCurrentDirectory(), "Skills");
var skill = kernel.ImportSemanticSkillFromDirectory(skillsDir, "HRAssistantSkill");

var context = new ContextVariables();
context.Set("input", "I'm 24 years old and I'm interested in technology. I love to explore new trends and learn.");

var result = await kernel.RunAsync(context, skill["Role"]);

Console.WriteLine(result);
