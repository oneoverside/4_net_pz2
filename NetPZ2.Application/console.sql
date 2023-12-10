CREATE TABLE Translation (
    TranslationId INTEGER PRIMARY KEY AUTOINCREMENT,
    Sentence TEXT,
    SentenceTranslate TEXT,
    Rating REAL
);

CREATE TABLE Tag (
    TagText TEXT primary key 
);

CREATE TABLE TranslationTag (
    TranslationTagId INTEGER PRIMARY KEY,
    TranslationId INTEGER,
    TagText TEXT,
    FOREIGN KEY (TagText) REFERENCES Tag(TagText) ON DELETE CASCADE,
    FOREIGN KEY (TranslationId) REFERENCES Translation(TranslationId) ON DELETE CASCADE
);