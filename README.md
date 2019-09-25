# Umbraco Examine Config

<img src="docs/img/logo.png?raw=true" alt="Umbraco Examine Config" width="250" align="right" />

[![NuGet release](https://img.shields.io/nuget/v/Our.Umbraco.ExamineConfig.svg)](https://www.nuget.org/packages/Our.Umbraco.ExamineConfig/)
[![Our Umbraco project page](https://img.shields.io/badge/our-umbraco-orange.svg)](https://our.umbraco.com/projects/developer-tools/examine-config/)

Configure Umbraco Examine indexes from the web.config!

In Umbraco 7 Examine indexes were configured via the friendly `ExamineIndexes.config` and `ExamineSettings.config` files. However in Umbraco 8 this configuration has moved into code, perhaps making it more difficult to configure indexes as desired. This project aims to replicate many of the helpful features of the Umbraco 7 Examine config files within Umbraco 8.

## Getting started

This package is supported on Umbraco 8.1+.

### Installation

The package is available from Our Umbraco, NuGet, or as a manual download directly from GitHub.

#### Our Umbraco repository

You can find a downloadable package, along with a discussion forum for this package, on the [Our Umbraco](https://our.umbraco.com/projects/developer-tools/examine-config/) site.

#### NuGet package repository

To [install from NuGet](https://www.nuget.org/packages/Our.Umbraco.ExamineConfig/), run the following command in your instance of Visual Studio.

    PM> Install-Package Our.Umbraco.ExamineConfig

## Usage

The package can be used to configure settings for the "Internal", "External" and "Media" Examine indexes in Umbraco.

It is possible to configure the following settings per index:

| Name                    | Type    | Default    |
|-------------------------|---------|------------|
| ParentId                | Integer | `-1`       |
| IncludeItemTypes        | Array   | Everything |
| ExcludeItemTypes        | Array   | Nothing    |
| SupportProtectedContent | Boolean | `false`    |

Settings are configured within the appsettings section of your `web.config` file for your Umbraco install. Appsetting names follow a convention of: `Umbraco.Examine.{INDEX-NAME}.{SETTING-NAME}`.

For example, to enable `SupportProtectedContent` for the "External" the name would be `Umbraco.Examine.ExternalIndex.SupportProtectedContent`.

## Contribution guidelines

To raise a new bug, create an issue on the GitHub repository. To fix a bug or add new features, fork the repository and send a pull request with your changes. Feel free to add ideas to the repository's issues list if you would to discuss anything related to the library.

### Who do I talk to?

This project is maintained by [Callum Whyte](https://callumwhyte.com/) and contributors. If you have any questions about the project please get in touch on [Twitter](https://twitter.com/callumbwhyte), or by raising an issue on GitHub.

## Credits

The package logo uses the [Search](https://thenounproject.com/term/search/2077536/) icon from the [Noun Project](https://thenounproject.com) by [Mochammad Kafi](https://thenounproject.com/mochammadkafi/), licensed under [CC BY 3.0 US](https://creativecommons.org/licenses/by/3.0/us/).

## License

Copyright &copy; 2019 [Callum Whyte](https://callumwhyte.com/), and other contributors

Licensed under the [MIT License](LICENSE.md).