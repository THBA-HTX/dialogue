INCLUDE globals.ink

// conditional statement
{ hasSpellbook == true : -> HasBook | -> StartDialog }

=== HasBook
You already bleeded me dry  stole my spellbook, and humiliated me.. what do you want now ?
-> DONE

=== StartDialog
Greetings.. ..   
-> DONE
