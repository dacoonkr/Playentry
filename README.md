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

## class Project

### GetThumbnailURL()

>   Get project's thumbnail image URL.
>
>   **Returns**
>
>   >   URL of project's thumbnail image.
>
>   **Return Type**
>
>   >string

### GetProjectLikesGroup()

>   Get the group of likes for project.
>
>   **Returns**
>
>   >   The group of likes for project.
>
>   **Return Type**
>
>   >   ProjectLikesGroup

### GetProjectFavoritesGroup()

>   Get the group of favorites for project.
>
>   **Returns**
>
>   >   The group of favorites for project.
>
>   **Return Type**
>
>   >   ProjectFavoritesGroup

### GetProjectCommentGroup()

>   Get the group of comments on project.
>
>   **Returns**
>
>   >   The group of comments on project.
>
>   **Return Type**
>
>   >   ProjectCommentGroup

### ProjectId

>   The project's unique ID.
>
>   **Type**
>
>   >   string

### ProjectName

>   The project's title.
>
>   **Type**
>
>   >   string

### ProjectDescription

>   The project's description content.
>
>   **Type**
>
>   >   string

### ProjectCategory

>   The project's category.
>
>   **Type**
>
>   >   enum ProjectCategorySet

### UserID

>   The project's author's unique ID.
>
>   **Type**
>
>   >   string

### UserName

>   The project's author's unique name.
>
>   **Type**
>
>   >   string


### Visit

>   The views of project.
>
>   **Type**
>
>   >   int


### Like

>   The number of likes for project.
>
>   **Type**
>
>   >   int


### Comment

>   The number of comments on project.
>
>   **Type**
>
>   >   int


### Favorite

>   The number of favorites for project.
>
>   **Type**
>
>   >   int

### ChildrenCount

>   The number of copies of project.
>
>   **Type**
>
>   >   int

### CreatedUTC

>   `This time is based on UTC.`
>
>   The time when project was created.
>
>   **Type**
>
>   >   DateTime

### LastEditedUTC

>   `This time is based on UTC.`
>
>   The time when project was last modified.
>
>   **Type**
>
>   >   DateTime





