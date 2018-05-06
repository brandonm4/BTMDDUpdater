BMIT - BattleTech Metadatabase Import Tool

This is a tool that reads the json mechdef files and updates the db.  This is to allow you to use custom mechs in the campaign.  If properly tagged they will show up as enemies during random contracts.

NOTE: You must make sure the csv contains your mechdefs and that they are properly formed (make sure they work in skirmish mode). Make sure they are working as you intend by testing them in Skirmish mode before attempting to import them using this tool.  

This is very much an alpha/test release to see if it can handle various mechdefs.

It will both create new mech records or update existing mech records if one already exists for that mech id.

It does the following

    It checks to see if there's a TagSetID for this mechDef ID.  If not, it creates a new one.  If so, it grabs the existing one.
    It creates or updates the UnitDef table using the values from the JSON.  This will allow you to change the values by changing the json and then running the update.
    It creates or updates the TagSetTag table.  If you remove MechTags from the JSON they will be removed from the db as well.

    -Download from GitHub - https://github.com/brandonm4/BTMDDUpdater/releases/tag/v.01a
    -Put all the mechdefs you want to update or import into one folder.
    -Run the tool
	--Go to Settings tab
    --Change the first box (MechDefs Path) to point to the folder where you copied all your files.
    --Change the second to point to your MetadataDatabase.md file. (In your games MDD folder).  It will make a backup before making any changes.
    -Go to Basic Tab. Press the Start Import button.  Wait for it to say complete. (at bottom)           
    --See if it worked and didn't blow up
    -i have been able to load an existing game save (created on an unmodded game)
    -I have encountered the new mechs in the campaign contracts
    -I have been able to salvage them - I haven't collected a full mech yet

I will refine the UI to allow you to pick your mechdef folder and mdd location in the future, but for now I want to make sure you don't accidentally overwrite your game data until you are sure you have a backup.
Edit: I added a better UI/progress bar as well as directories for your file locations.  You can change them by either editing the textbox or for a permanent change - edit the .config file and change the two directories at the bottom of the file.
Edit 2: I was able to add all of JK_Varients(https://www.nexusmods.com/battletech/mods/18) into the DB (I had to fix the json on one of the vindicators).  I am able to load my save and get into the campaign.  I'll play some now (for testing... ) to see if any of the new ones show up. Also, I had to reorder the csv entries (MoveDefs before Chassis before MechDefs) to get the game to load.
Next up will be some more UI changes.
