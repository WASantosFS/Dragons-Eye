# Project Name: Dragon's Eye

## Purpose
To develop an Enigma machine-inspired enciphering program.

## Description
 This project started after the initial development of Steel Iris (an Enigma Machine emulator) ran into road blocks that, due to unmaintanable code, had to be placed on hold. Steel Iris did not follow the TDD paradigm. Following TDD, Dragon's Eye has yielded a much more managable program. The development is much more strict in that each iterative step must yield a working program in that it can encipher and decipher.

## Solution Contents
### Database Construction (and Tests)
These projects handle the creation of the database, but also act as the testing ground for the SQL queries eventually used within the Backend. Used to populate *dbo.daily_settings* and *dbo.bigrams* via a class of random generation methods. The other tables held in the original design may be removed due to simplification and realization that they aren't genuinely required due to the nature of their purpose. The associated test project is lightweight in nature due to repetitiveness: tests run to get one table populated will work equally well with very minor tweaks dealing with which RG methods to call.

### Logic (and Tests)
These projects are essentially the core of how everything works for the cipher. They are incomplete. (See 'To Do') However, the central operating core is complete and entirely functional. It is a C# class library and one of the more heavily tested projects -- with more to come, certainly.

### Backend APIs
The core for linking the local or Azure DB to pull required settings to encipher or decipher. Uses methods from the logic library as well.

### Console App
A stand-alone console app that can be released to both Windows and Mac. Allows a dedicated program that interacts with the Azure DB and Web App Services to cipher and decipher. More functionality might be implemented, but at the moment it does its job as being a dedicated UI.

## To Do
### Logic
- Offsets
- Plugboard
- Indicators

### Backend
- Weather API integration
- Implement IP pull to get weather

### Frontend
- Develop Vue website
- Finish development of standalone desktop app
