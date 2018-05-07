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


Instructions


    Go here: https://github.com/brandonm4/BTMDDUpdater/releases/tag/v.01a and download whatever the latest is - right now it's .05a but I'm updating it frequently

    Unzip it, it doesn't matter where - on your desktop is fine for now.

    Copy all your mechdefs into one single folder - for instance if you use the JK_Varients they would by default be in C:\Program Files(x86)\G:\Steam\steamapps\common\BATTLETECH\BattleTech_Data\StreamingAssets\data\mods\JK_Variants\mech - it's ok to leave them there.

    Go into the BMIT folder that you unzipped and click on BMIT.exe

        If for some reason this doesn't run - make sure you have the latest .net framework installed from here: https://support.microsoft.com/en-us/help/3186497/the-net-framework-4-7-offline-installer-for-windows

    Once it's running go to the Settings Tab and paste into the MechDef Path textbox the path to your mechdefs folder that you made in step 3 - (C:\Program Files (x86)\Steam\steamapps\common\BATTLETECH\BattleTech_Data\StreamingAssets\data\mods\JK_Variants\mech in this example)

    In the next textbox MDD Path - paste in the full path to your MetadataDatabase.db file - C:\Program Files (x86)\Steam\steamapps\common\BATTLETECH\BattleTech_Data\StreamingAssets\MDD\MetadataDatabase.db - unless you've installed your steam library somewhere else or if you use GOG you'll have to find that file yourself.

    Click Save Settings on this tab so you don't have to keep doing step 5 and 6

    Click on the Basic Tab

    Click the Import button. Watch the pretty green bar at the bottom until it says complete. :)

    If you get an error right after starting send it to me.

    If the green bar is not moving there is a problem with finding or accessing your .md file.

    If this fails for any reason - restore your original db file. There will a file named MetadataDatabase.md-<TimeStamp>.bak in the same as the original. This is a copy from before any changes were made. Delete the existing MetadataDatabase.md and rename the .bak file to MetadataDatabase.md

Another important thing is that make sure the mechs really work in skirmish before you do any of this.
You can test this by doing a few things. First make sure the game loads to the main menu. (it originally stalled for me here with a black screen and 59 in the top corner) Second, once you are on the main menu, make sure you can start a skirmish game with any of the new mechs. (This part failed for me with it sitting in continual loading). Finally make sure you can load your existing campaign save. (Until I fixed the csv, the Continue button was greyed out). Make sure of all of this before you bother with my importer. Otherwise you will probably break your game.


