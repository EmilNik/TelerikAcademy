namespace JustAsk.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using JustAsk.Common;

    using Microsoft.AspNet.Identity;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Ideas.Any())
            {
                var hasher = new PasswordHasher();
                var randomGenerator = new RandomGenerator();
                var hashedPass = hasher.HashPassword(GlobalConstants.AdministratorPassword);
                var user = new ApplicationUser()
                {
                    UserName = GlobalConstants.AdministratorUserName,
                    PasswordHash = hashedPass,
                    SecurityStamp = hashedPass
                };

                context.Users.Add(user);
                context.SaveChanges();

                var titles = new List<string>()
                {
                    "XNA 5",
                    "Allow .NET games on Xbox One",
                    "Support web.config style Transforms on any file in any project type",
                    "Bring back Macros",
                    "Open source Silverlight",
                    "Native DirectX 11 support for WPF",
                    "Make WPF open-source and accept pull-requests from the community",
                    "Fix 260 character file name length limitation",
                    "Support for ES6 modules",
                    "Create a remove all remnants of Visual Studio from your system program.",
                    "Support .NET Builds without requiring Visual Studio on the server",
                    "VS IDE should support file patterns in project files",
                    "Improve WPF performance",
                    "T4 editing",
                    "Visual Studio for Mac Os x"
                };

                var descriptions = new List<string>()
                {
                    @"Please continue to work on XNA. It's a great way for indie game developers like myself to make games and give them to the world. XNA gave us the ability to put our games, easily, on the most popular platforms, and to just dump XNA would be therefor heartbreaking... I implore you to keep working on XNA so we C# developers can still make amazing games!",
                    @"Yesterday was announced that Xbox One will allow indie developer to easily publish games on Xbox One.

Lots of indie developers and small game company are using .NET to develop games.Today, we are able to easily target several Windows platforms(Windows Desktop, Windows RT and Windows Phone 8) as well as other platforms thanks to Mono from Xamarin.

As we don't know yet the details about this indie developer program for Xbox One, we would love to use .NET on this platform - with everything accessible, from latest 4.5 with async, to unsafe code and native code access through DLLImport (and not only through WinRT components)

Please make .NET a compelling game development alternative on Xbox One!",
                    @"Web.config Transforms offer a great way to handle environment-specific settings. XML and other files frequently warrant similar changes when building for development (Debug), SIT, UAT, and production (Release). It is easy to create additional build configurations to support multiple environments via transforms. Unfortunately, not everything can be handled in web.config files many settings need to be changed in xml or other ""config"" files.

Also, this functionality is needed in other project types - most notably SharePoint 2010 projects.",
                    @"I am amazed you've decided to remove Macros from Visual Studio. Not only are they useful for general programming, but they're a great way to be introduced to the Visual Studio APIs.

If you are unwilling to put in the development time towards them, please release the source code and let the community maintain it as an extension.",
                    @"Blog post at http://davidburela.wordpress.com/2013/11/22/is-it-time-to-open-source-silverlight/

For all intents and purposes Microsoft now views Silverlight as “Done”. While it is no longer in active development it is still being “supported” through to 2021 (source).

However there is still a section of the .Net community that would like to see further development done on the Silverlight framework. A quick look at some common request lists brings up the following stats:

* 5,720+ votes to release Silverlight 6 https://visualstudio.uservoice.com/forums/121579-visual-studio/suggestions/3556619-silverlight-6 
* Feature requests for Silverlight http://dotnet.uservoice.com/forums/4325-silverlight-feature-suggestions 
* Microsoft connect list of active Silverlight feature requests: http://connect.microsoft.com/VisualStudio/SearchResults.aspx?KeywordSearchIn=2&SearchQuery=%22silverlight%22&FeedbackType=2&Status=1&Scope=0&SortOrder=10&TabView=1 
Rather than letting Silverlight decay in a locked up source control in the Microsoft vaults, I call on them to instead release it into the hands of the community to see what they can build with it. Microsoft may no longer have a long term vision for it, but the community itself may find ways to extend it in ways Microsoft didn’t envision. 
Earlier this year Microsoft open sourced RIA Services on Outer Curve http://www.outercurve.org/Galleries/ASPNETOpenSourceGallery/OpenRIAServices, it would be great to see this extended to the entire Silverlight framework.",
                    @"in 2013 WPF still work on DX9, and this have a lot of inconvenience. First of all it is almost impossible to make interaction with native DX11 C++ and WPF. Axisting D3DImage class support only DX 9, but not higher and for now it is a lot of pain to attach DX 11 engine to WPF.

Please, make nativa support for DX 11 in WOF by default and update D3DImage class to have possibility to work with nativa C++ DX 11 engine and make render directly to WPF control (controls) without pain with C++ dll.",
                    @"Please follow the footsteps of the ASP .NET team and make WPF open-source with the source code on GitHub, and accept pull-requests from the community.",
                    @"Same description as here:

http://visualstudio.uservoice.com/forums/121579-visual-studio/suggestions/2156195-fix-260-character-file-name-length-limitation",
                    @"Add support for the new JavaScript ES6 module syntax, including module definition and imports.",
                    @"I'm writing this on behalf of the thousands of other Visual Studio users out there who have had nightmares trying to uninstall previous versions of VS. Thus cumulatively losing hundreds of thousands of productive work hours.

During this year, I had installed the following programs/components on my system: 
* Visual Studio 2012 Express for Desktop 
* Visual Studio 2012 Express for Web 
* Team Foundation Server Express 
* SQL Server Express 
* SQL Server Data Tools 
* LightSwitch 2011 trial (which created a VS 2010 installation) 
* Visual Studio 2010 Tools for SQL Server Compact 3.5 SP2 
* Entity Framework Designer for Visual Studio 2012 
* Visual Studio Tools for Applications 
* Visual Studio Tools for Office 
* F# Tools for Visual Studio Express 2012 for Web

Two weeks ago I discovered that third-party controls can't be added to the Express versions of VS. I'm disabled and live on a fixed income, so spending $500 for the Professional version, in order to continue my hobby programming with a third-party control, was a tough decision. But I bought it.

When it arrived, I figured it would take an hour or two to remove the above programs and then I could install the Pro version. I wanted to have a clean file system and Registry for the new install of VS Pro.

It's now SIX DAYS later, and my spending 12-14 hours a day working on this alone. Removing these programs was the biggest nightmare I have ever faced with Microsoft products in my 30 years of being a Microsoft customer. Each one of these products automatically installed 5, 10 or more additional components, along with many thousands of files and individual Registry entries.

It took me four days alone, just to successfully remove the LightSwitch 2011 trial, and the entire VS 2010 product it installed. Restoring a 600 GB disk drive (5 hours) from backup after every removal attempt failed miserably. I finally gave up, spent 6 hours downloading the entire VS 2010 ISO and installed it. Only then, was I able to successfully uninstall LightSwitch 2011 and VS 2010.

As for the remaining products listed above, the uninstall programs do NOT UNinstall everything that they automatically INstall. Every single, automatically INstalled component, had to be removed manually, one at a time. Along with manually creating a System Restore point before each removal attempt, in case it failed. In total, I spent 12 hours uninstalling the remaining products.

I have a Registry search program where I can enter a search string and it will list ALL occurrences it finds in the Registry. I checked ""visual studio"", ""visualstudio"", ""vbexpress"", ""vcexpress"", ""SQL Server"", etc. I never finished searching for all the possible Visual Studio and SQL Server strings because the results being returned were eye-popping. Each search was returning 1,000, 3,000, even 7,000 individual Registry entries that had NOT been removed by the individual uninstall processes. This is TENS of THOUSANDS of never to be used again Registry entries that these programs simply left behind. The size of my Registry file is now a stunning 691 MB!

All of this frustration and wasted time is completely avoidable! And my case is not ""isolated"". There are hundreds of thousands of hits on Google regarding this problem, that point to Microsoft forums, MS Blog sites, and many independent Windows developer support forums on the web.

Microsoft really should provide an uninstall program that actually works, by UNinstalling everything it INstalls -- for each product it sells-- including Visual Studio.The downloadable(from Microsoft) uninstall program for VS 2010 does not work correctly and does not remove everything that VS 2010 installs.

When a program installs multiple individual components, tens of thousands of files and Registry entries, it SHOULD have an uninstaller that removes ALL of this, automatically, just like the install program.The OS and Registry keep track of dependencies and you folks know what the removal order should be for all of these products.So the team that creates the INstall program for each product, should also create the UNinstall program.And, the product should NOT ship until this program works correctly and fully.

You have ONE install program for each version of Visual Studio, that asks the user what they want to install and then does it ALL automatically.You should also have ONE uninstall program that does the same thing in reverse...
* Collect info on all the VS - related products and components currently installed
* Ask the user what they want to remove
* Determine if their selections make sense
* Check for dependencies by using your knowledge and experience, along with the computer's stored information, and warn the user as needed 
* Decide on the removal order
*Then do it ALL automatically-- removing ALL files and ALL Registry entries

When you release a new product version, ADD the new version and additional decision logic to this existing program, do NOT create a new uninstall program.This way, the user can also remove previous version products, components, etc.ONE uninstall program* should be* able to uninstall every version of Visual Studio released in the past 10 years, along with every single component that was available with it, AND all of the associated files and Registry entries.

Please don't tell us why it CAN'T be done.Rather, figure out a way to do it, and then make it happen, just like every other software company out there has already done for their products. Even FREEware providers have better uninstall processes than Microsoft.This is a sad state for Microsoft and it should be rectified SOON.

Thank you.",
                    @"To build certain PCL libraries and libraries for Windows 8 RT requires having Visual Studio on the server.

Nick Berardi writes about a workaround that allows running a build server without VS, but it's really just a workaround for functionality that should be easy.

Not to mention there's probably licensing considerations we're just ignoring by doing that.

http://nickberardi.com/a-net-build-server-without-visual-studio/

Please make it easy (and legal) to build .NET projects on a server without requiring a Visual Studio installation (or license) on that server.",
                    @"Patterns should be preserved and unmodified when working with *proj files. If I specify a pattern with something like **/*.cs for my code files. If I add a new .cs file that fits that pattern the .csproj file should not be modified.

MSBuild already respects this, but the IDE will always modify the project file.

For numerous scenarios this could simplify the diff / merge process",
                    @"I have a high end PC and still WPF is not always fluent. Just compare it with QT 4.6 QML (Declarative UI) it is sooo FAST!",
                    @"T4 is no longer just a tool used internally by VS, but is being increasingly used by developers for code generation. It would be great to have syntax highlighting, intellisense etc. out of the box.

I appreciate this is probably more of a Visual Studio feature request than an ASP.NET one, but as T4 is used a lot within ASP.NET projects, particularly MVC ones, I figure it's worth a mention.",
                    @"Dear Madam and sir;

We need Full Version of Visual Studio for Mac Os x. 
And language of programming such as:

-C 
-C++ 
-C# 
-VB 
-F# 
-HTML 
-MHTML

Thanks"
                };

                var comments = new List<string>()
                {
                    @"The same issue exists with SQL Server Data Tools and Visual Studio SQL projects. It is still a huge hassle to get SSDT installed without Visual Studio.",
                    @"I have spent countless hours trying to get builds working without Visual Studio. There are so many dlls and target files and other references that are included within the Visual Studio install that are not available elsewhere that I have now given up.

The final straw for me was SQL database projects. I just could not see a way of building them without Visual Studio installed. Any approach which I looked at was extremely brittle and would be hard to keep up-to-date.

I really do not understand why Microsoft do not create an install package for build servers that does not include the tens of GB of unnecessary files that come with Visual Studio. There are crazy things like the .target files shipping only with Visual Studio rather than MSBuild, why would you not include these in MSBuild or the build agents package?

Our build servers now use almost 60GB of disk space, the majority of which is not required simply to get builds to work. This is a fine example of bloat and one of the reasons people turn to open source alternatives.

A comment from Microsoft on this issue would be very much appreciated.",
                    @"I'd just like to point out it's 2015, and developers still have to install 10 GBs of Visual Studio to simply compile one damned package. 
Congrats.",
                    @"How is this even an issue in 2015? Who in their right mind would require a build server to have a full version of Visual Studio (with all its bloat and problems installing/upgrading) installed?

I truly regret choosing .NET as platform for our company, it simply isn't mature yet, even after all these years.",
                    @"I mentioned this to MSFT 5 years ago, and their official response was ""As Designed""...",
                    @"@martin. No, the build environment should be as stripped bare as possible to make sure there is nothing on it, in the gac, etc that mean it can build in one environment but not another. ""works on my machine"" pseudo-certification should be avoided, and can be with a clean room build server, so +1 from me...",
                    @"I would very much like to see a special build server MSI installer - which shoud install only the necessary stuff required to build .NET Projects made from Visual Studio (without VS itself). Not only Windows 8 builds requires workarounds if VS is not installed

Here is a few examples we had to deal with at GN ReSound:

1) Put Microsoft unittesting dll's in NuGet packages - normally located in the GAC here: 
""C:\Windows\Microsoft.NET\assembly\GAC_MSIL\Microsoft.VisualStudio.QualityTools.UnitTestFramework""

2) Add another Visual Studio Web Publishing dll to source control (C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v11.0\Web\Microsoft.Web.Publishing.Tasks.dll).

Above is just examples, I'm sure many other task, build and test stuff is missing if VS is not installed on a build server.

3 votes from me",
                    @"Should I point out that there are no licencing considerations with this. You are free to install VS Ultimate on all of your build servers if your organisation owns even a single Ultimate licence. Your build server should reflect your development environment and not your production one... there is no compelling reason to invest in not requiring VS on the build server.",
                    @"I agree, although the request should be stated differently. 
The request should be: make Visual Studio, as an application, lighter, more portable and more self-contained (everything under one folder like Eclipse, or all the others). 
And this would automatically drive the separation of interests between the tools, the IDE, and so on. 
Additionally, when we install several VS versions it's ****!. All the DLLs, different folders, csproj associations, etc.",
                    @"Can't believe this is still a thing in this day and age."
                };

                var count = 0;

                for (int i = 0; i < 15; i++)
                {
                    var description = descriptions[i].Replace(Environment.NewLine, "<br />");
                    var idea = new Idea()
                    {
                        Title = titles[i],
                        Description = descriptions[i],
                        AuthorIP = randomGenerator.GetRandomIp()
                    };

                    for (int j = 0; j < 15; j++)
                    {
                        var comment = new Comment()
                        {
                            AuthorId = randomGenerator.GetRandomIp(),
                            Content = comments[count % comments.Count],
                            AuthorEmail = $"user{i}{j}{i}@site.com"
                        };
                        context.Comments.Add(comment);

                        idea.Comments.Add(comment);
                        count++;
                    }

                    for (int k = 0; k < 50; k++)
                    {
                        var vote = new Vote()
                        {
                            AuthorId = randomGenerator.GetRandomIp(),
                            Value = (VoteType)randomGenerator.GetRandomNumber(GlobalConstants.MinVoteValue, GlobalConstants.MaxVoteValue)
                        };

                        context.Votes.Add(vote);
                        idea.TotalVotes = idea.TotalVotes + (int)vote.Value;
                        idea.Votes.Add(vote);
                    }

                    context.Ideas.Add(idea);
                    context.SaveChanges();
                }
            }
        }
    }
}
