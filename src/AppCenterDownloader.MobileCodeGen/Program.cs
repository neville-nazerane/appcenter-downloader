using CodeGeneratorHelpers.Maui.Models;
using Maui.CodeGeneratorHelpers;







await CodeGenerationBuilder.WithNewInstance()
                           
                           .WithMobileProjectName("AppCenterDownloader.MobileApp")
                           .WithExecutionLocations("AppCenterDownloader.MobileCodeGen")

                           .AddPageToViewModelEvent(PageEventType.OnNavigatedTo, "OnNavigatedTo")
                           .AddPageToViewModelEvent(PageEventType.OnNavigatedTo, "OnNavigatedToAsync", true)

                           .GenerateAsync();