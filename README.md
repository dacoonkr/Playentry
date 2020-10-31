# Introduce

#### Unofficial API Wrapper for .NET

It's available on NuGet! [Go to NuGet Package](https://www.nuget.org/packages/Playentry)

#### What is Playentry?

Playentry is a software training platform developed so that anyone can take software training for free. [Go to Playentry](https://playentry.org)

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

## class ProjectThumbnail

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

### GetProject()

>   Get detail project class from thumbnail.
>
>   **Returns**
>
>   >   Detail project class from thumbnail.
>
>   **Return Type**
>
>   >   Project

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

### Created

>   `This time is based on UTC.`
>
>   The time when project was created.
>
>   **Type**
>
>   >   DateTime

### LastEdited

>   `This time is based on UTC.`
>
>   The time when project was last modified.
>
>   **Type**
>
>   >   DateTime

## class ProjectLikesGroup

### ProjectID

>   The unique ID of target project.
>
>   **Type**
>
>   >    string

### Count

>   The number of likes.
>
>   **Type**
>
>   >   int

### List

>   The list of likes.
>
>   **Type**
>
>   >   List\<ProjectLike>

## class ProjectLike

### LikeID

>   The unique ID of likes.
>
>   **Type**
>
>   >   string

### UserID

>   The likes' user's unique ID.
>
>   **Type**
>
>   >   string

### UserName

>   The likes' user's unique name.
>
>   **Type**
>
>   >   string

### ProjectId

>   The target project's unique ID.
>
>   **Type**
>
>   >   string


## class ProjectFavoritesGroup

### ProjectID

>   The unique ID of target project.
>
>   **Type**
>
>   >    string

### Count

>   The number of favorites.
>
>   **Type**
>
>   >   int

### List

>   The list of favorites.
>
>   **Type**
>
>   >   List\<ProjectFavorite>

## class ProjectFavorite

### LikeID

>   The unique ID of favorites.
>
>   **Type**
>
>   >   string

### UserID

>   The favorites' user's unique ID.
>
>   **Type**
>
>   >   string

### UserName

>   The favorites' user's unique name.
>
>   **Type**
>
>   >   string

### ProjectId

>   The target project's unique ID.
>
>   **Type**
>
>   >   string

## class ProjectCommentsGroup

### ProjectID

>   The unique ID of target project.
>
>   **Type**
>
>   >    string

### Count

>   The number of comments.
>
>   **Type**
>
>   >   int

### List

>   The list of comments.
>
>   **Type**
>
>   >   List\<ProjectComment>

## class ProjectComment

### LikeID

>   The unique ID of comment.
>
>   **Type**
>
>   >   string

### UserID

>   The comment's user's unique ID.
>
>   **Type**
>
>   >   string

### UserName

>   The comment's user's unique name.
>
>   **Type**
>
>   >   string

### ProjectId

>   The target project's unique ID.
>
>   **Type**
>
>   >   string

### Content

>   The content of comment.
>
>   **Type**
>
>   >   string