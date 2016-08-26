# UDBase
Repository link: [https://github.com/KonH/UDBase](https://github.com/KonH/UDBase)

## Overview
*TODO*

## Install

### Using git-submodule
1. First time: 
	1. Add project as git-submodule to your Unity project: `git submodule add git@github.com:KonH/UDBase.git Assets/UDBase`
2. If you clone your project already with submodule:
	1. Initialize submodule: `git submodule init`
	2. Update submodule: `git submodule update`
3. Use UDBase/Setup to make default user project structure

### Manual
You can download last version here: [https://github.com/KonH/UDBase/archive/master.zip](https://github.com/KonH/UDBase/archive/master.zip)

## Update

### Using git-submodule
Just update submodule: `git submodule update`

### Manual
Also, you can re-install project as described above.

## Features
### Controllers
All logics in UDBase separated by controllers, that provide abstract interface to specific features. Controllers can be replaced in one place without any changes to other code. You can make your own controller, that implements your logics (based on existing or completely new interface). 

TODO: Example

### Controller helpers
You can call any controller logics using helpers, that provide static methods, hides concrete controller instance.
 
TODO: Example 

### Schemes
Using schemes you can easily switch controllers or disable it. It based on scripting define symbols and don't cause runtime overhead.

TODO: Example

## Examples
Example project - [https://github.com/KonH/UDBaseExample](https://github.com/KonH/UDBaseExample)

## License
See **LICENSE.txt** beside.
