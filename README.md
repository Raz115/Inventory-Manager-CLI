# Inventory-Manager-CLI
Inventory Manager CLI is a command-line tool managing a stores inventory of movies, books, and games. It allows users to add, modify, delete, sort, and search items by attributes like cost, genre, platform, and release year. The program simulates a small business keeping their inventory organized and up to date.


## Output File
The application generates an output file named: `MirzaR_PASS2.txt`
This file will be located in the `bin/Debug/net9.0` folder of the project. The output records the results of actions performed on the inventory.

## Note on Dynamic Inventory Updates
The inventory updates after each run, meaning that the output will differ with every execution as actions are processed. If you want to re-run the application from the initial state:

1) Delete Existing Files:
    Navigate to the `bin/Debug/net9.0` folder.
    Delete the following files:
      `actions.txt`
      `inventory.txt`

2) Restore Original Files:
    Go to the `InOutFiles` folder in the project directory.
    Copy the original `inventory.txt` and `actions.txt` files. 
    Paste them into the `bin\Debug\net9.0` folder.

## How to Run the Application
Double Click the `InventoryManagerCli.exe` file in the `bin/Debug/net9.0` folder.


## Verify correct output
### Output File: 
Check the `MirzaR_PASS2.txt` file in the `bin/Debug/net9.0` folder.
It should contain the actions processed and their results.

Check the `inventory.txt` file in the `bin/Debug/net9.0` folder.
It should contain the current inventory after the actions were processed.

###Compare 
Compare the  `MirzaR_PASS2.txt` file with the `expectedOutput.txt` found in the `InOutFiles` folder for reference.
Similarly compare `inventory.txt` file with the `updatedInventory.txt` in the same folder 
