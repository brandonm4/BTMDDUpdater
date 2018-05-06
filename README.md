# BTMDDUpdater
BMIT - BattleTech MDD Mech Importer
I've created a .net tool that reads the json mechdef files and updates the db. Mainly because i wanted to add new varients to the db and didn't want to type it all in manually. This is so your custom mechs/variants will show up in the campaign.

You must make sure the csv contains your mechdefs and that they are properly formed (make sure they work in skirmish mode).

This is very much an alpha/test release to see if it can handle various mechdefs.

It should do either - create a new entry if one is not found (using the ID in the UnitDef table)

or if it does find one, it should update that one with your files info.

    Download from GitHub - https://github.com/brandonm4/BTMDDUpdater/releases/tag/v.01a

    Copy your mechdefs you want to import (I used some the JKVarients) to the \test\mechs folder in the tool

    Copy your MetadataDatabase.db to the \test\ folder in the tool folder

    Run the tool, press the button.

    Backup your original game folder MetadataDatabase.db

    Copy the modified MetadataDatabase.db from the \test\ folder back to your originalgames mdd folder.

    See if it worked and didn't blow up

I will refine the UI to allow you to pick your mechdef folder and mdd location in the future, but for now I want to make sure you don't accidentally overwrite your game data until you are sure you have a backup.

Edit: I added a better UI/progress bar as well as directories for your file locations. You can change them by either editing the textbox or for a permanent change - edit the .config file and change the two directories at the bottom of the file.

Edit 2: I was able to add all of JK_Varients(https://www.nexusmods.com/battletech/mods/18) into the DB (I had to fix the json on one of the vindicators). I am able to load my save and get into the campaign. I'll play some now (for testing... ) to see if any of the new ones show up. Also, I had to reorder the csv entries (MoveDefs before Chassis before MechDefs) to get the game to load.

Next up will be some more UI changes.
