# User

UserSystem is a simple storage for user information.

## Basics

Now it store user name only.

## Usage

You need to add controller to your scheme and save dependency:

```
var save = new FsJsonDataSave().AddNode<UserSaveNode>("user");
AddController<User>(new SaveUser());

```

After it, you can get/set user name via **User.Name** and it has beed saved between sessions.
