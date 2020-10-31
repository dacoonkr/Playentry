# Introduce

#### Unofficial API Wrapper for .NET

It's available on NuGet! <button onclick="https://www.nuget.org/packages/Playentry/">Go to NuGet Package</button>

#### What is Playentry?

Playentry is a software training platform developed so that anyone can take software training for free. <button onclick="https://playentry.org">Go to Playentry</button>

#### Usage

~~~c#
using Playentry;
~~~

# Classes

## class PlayentryClient

### GetStaffPicks([int limit = 3])

>   Get recent staffpick-projects.
>
>   **Parameters**
>
>   >   **limit** (int): Number of projects to get.
>
>   **Returns**
>
>   >   List of recent staffpick-projects.
>
>   **Return Type**
>
>   >   List\<ProjectThumbnail>

### GetBestProjects([int limit = 9])

>   Get current best-projects.
>
>   **Parameters**
>
>   >    **limit** (int): Number of projects to get.
>
>   **Returns**
>
>   >   List of current best-projects.
>
>   **Return Type**
>
>   >   List\<ProjectThumbnail>