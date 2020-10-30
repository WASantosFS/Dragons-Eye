Project Name: Dragon's Eye

Purpose: To develop an Enigma machine-inspired enciphering program.

Description: This project started after the initial development of Steel Iris (an Enigma Machine emulator) ran into road blocks that, due to unmaintanable code, had to be placed on hold. Steel Iris did not follow the TDD paradigm. Following TDD, Dragon's Eye has yielded a much more managable program. The development is much more strict in that each iterative step must yield a working program in that it can encipher and decipher.

TO-DO:
- [x] Shift method
- [x] Cipher method (1 ring)
- [x] Implement reflector
- [x] Implement reverse pass through
- [x] Initial character setting
- [x] Shift with each letter en/deciphered
- [x] Format method (Punctuation)
- [x] Group method (Groups of 4)
- [ ] Implement offsets
- [ ] Implement plugboard
- [ ] Implement 2 rings
- [ ] Implement 3 rings
- [ ] Implement 4 rings

BUGS:
- [ ] Cannot encipher or decipher back-to-back
- [x] Punctuation replacements can cause issues "way." -> "wa z"

User -> Message (request)
    - Request triggers:
        - Find local time, convert to UTC +0
        - Takes conversion and runs:
            Select * From daily_settings
            Where datetime = Last(datetime < @UTC);
        - Information is stored in a list
        - daily_settings.id is used to pull key_ind and enc_ind, both are stored
            - enc_id is encrypted by starting_positions
                - result replaces starting_positions
            - a method pulls out bigrams from key_ind and enc_ind
                - ex. (CATS, DOGS) => (CD, AO, TG, SS)
            - above list is used to reference the bigram row for that daily_setting.id.
                - replacement is done and separated
                    - appended to encrypted message at beginning
        - with crypto set, message is run through
        - displayed to user