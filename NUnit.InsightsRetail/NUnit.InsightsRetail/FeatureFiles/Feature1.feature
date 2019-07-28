Feature: Validate DropBox, Folder share functionality
		 Create folder and Upload files in DropBox
		 And Folder can be shared to any User.


Scenario: Verify user can upload files to a folder and can Share
	Given user autoTesting.user.01@gmail.com logs into the CE Client application
	Then  user NaviateTo 'Files'
	Then  user creates NewFolder 'TestFolder'
	Then  user upload files 'TestFile_1.txt' to 'TestFolder'
	Then  user can share 'TestFolder' to 'sureshnammi@gmail.com'

