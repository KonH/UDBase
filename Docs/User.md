# User

UserSystem is a simple storage for user information.

## Basics

Now it store: main user id, user name and set of identifiers for external providers.

## Usage

You need to add controller to your scheme and save dependency:

```
var save = new FsJsonDataSave().AddNode<UserSaveNode>("user");
AddController<User>(new SaveUser());

```

After it, you can get/set user id with **User.Id**, name via **User.Name**, add/get external ids with **User.AddExternalId**/**User.FindExternalId** and all information has beed saved between sessions.
