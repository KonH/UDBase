## Contribution Rules

### Summary

- You can create issues for new features or bugs found
- Do not use milestones, it's been set in approval process 
- You can send your pull requests with new controller implementation, fixes and non-broke changes (or make issue for significant changes before)
- Readability and simplicity are first, performance and dencity are last  

### Code Style

- Common:
	- One instruction per line 
	- *Use* tabs for indents and spaces for alignment
	- After the point there is *must be* a space 
	- After a semicolon, unless it is the last in a string (e.g. in the for statement) there is *must be* a space
	- Before opening bracket there is *must be* a space
	- *Do not* use like break before opening bracket
- Variable naming convention:
	- *pascalCase* - local var/method argument
	- *CamelCase* - public field, constants
	- *_pascalCase* - non-public field
	- *Do not* use abbreviations
- Classes:
	- Use noun and *CamelCase* for names
- Interfaces:
	- Use *CamelCase* starts with **I**, noun and/or adjective for names
- Enums:
	- Use *CamelCase* for names
	- *Do not* use **s** at ending
- Methods:
	- Use *CamelCase* and verbs for names
	- Use **Get** prefix for retrive something 
	- Use **Try** prefix and bool return value for process with uncertain result
- Fields:
	- One field declaration in line
	- Fields *must be* ordered and grouped by its type: consts, static, properties, public, non-public
	- Field group members *must be* aligned by type, name and equal sign (=) 
	- Field groups *must be* devided using white spaces
- Namespaces:
	- Use namespaces
	- Any namespace *must* start with **UDBase**
	- Namespace and class names *must be* differ
	- Combine several related classes in new namespace
- Files:
	- File and class name must be the same
	- One class/enum per file
	- Multiple structs may be combined in one file
- Specific cases:
	- Avoid using *foreach* loop for memory usage problems

### Approval Process

- Your issue can be taken in work or rejected by non-implementability, project architecture or common sense
- Fast issue resolving is not guaranteed
- Your pull requests would have been accepted, closed or back for revision according to **Code Style**, project architecture and common sense