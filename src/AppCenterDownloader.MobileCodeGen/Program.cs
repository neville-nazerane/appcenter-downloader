using CodeGeneratorHelpers.Maui.Models;
using Maui.CodeGeneratorHelpers;







await CodeGenerationBuilder.WithNewInstance()
                           
                           .WithMobileProjectName("AppCenterDownloader.MobileApp")
                           .WithExecutionLocations("AppCenterDownloader.MobileCodeGen")

                           .AddPageToViewModelEvent(PageEventType.OnBackButtonPressed, "OnBack")
                           .AddPageToViewModelEvent(PageEventType.OnBackButtonPressed, "OnBackAsync", true)
                           .AddPageToViewModelEvent(PageEventType.OnNavigatedTo, "OnNavigatedTo")
                           .AddPageToViewModelEvent(PageEventType.OnNavigatedTo, "OnNavigatedToAsync", true)

                           .GenerateAsync();