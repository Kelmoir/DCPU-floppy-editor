Licence:

You may:
- freely Fork it for new Open source projects.
- redistribute it.
- help programming it.

You may not
- claim credit of doing it alone. It is an open source project and has several contributors.
- make any closed source project out of it.
- inject malicious code into it, or redistribute it with malicious code in it. 



Summary:
A simple Interface to read, write, edit floppys for the DCPU-16 in 0x10c.
The supported Fs is the HA flavoured FAT16. 
//TODO: link some good document in here
internally it does the FS action with the abstraction Layer provided by cFAT.
From there it just recalculated the binary layout of the binary data representation after any change.

Stuff TODO:
-a lot (Viewing the FS, adding/removing files, loading and interpreting Floppys (to internal cFAT),.....
