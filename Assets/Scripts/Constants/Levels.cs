// [L01] 2 words, 4 letters, 4 shelves / 4 blocks: [BR] ROXO, BELO             / [EN] AURA, IDEA
// [L02] 3 words, 4 letters, 5 shelves / 4 blocks: [BR] LEVE, PENA, VOAR       / [EN] EVEN, MEGA, YEAR
// [L03] 2 words, 6 letters, 4 shelves / 6 blocks: [BR] UTOPIA, FUTURO         / [EN] UTOPIA, FUTURE
// [L04] 2 words, 5 letters, 4 shelves / 5 blocks: [BR] VAPOR, DOBRA           / [EN] VAPOR, BOARD
// [L05] 2 words, 5 letters, 4 shelves / 5 blocks: [BR] MATIZ, CORES           / [EN] MAGIC, COLOR
// [L06] 3 words, 5 letters, 5 shelves / 5 blocks: [BR] TARDE, PRAIA, BLOCO    / [EN] AFTER, BEACH, BLOCK
// [L07] 3 words, 5 letters, 5 shelves / 5 blocks: [BR] VINDO, CRINA, PINTA    / [EN] WINDY, DRINK, PAINT
// [L08] 3 words, 6 letters, 5 shelves / 6 blocks: [BR] TIMBRE, MUSEUS, CABANA / [EN] SYMBOL, MUZZLE, BANANA
// [L09] 3 words, 6 letters, 4 shelves / 6 blocks: [BR] SERENO, CABELO, ANTENA / [EN] SEREST, GAZEBO, ANTHEM
// [L10] 3 words, 6 letters, 4 shelves / 6 blocks: [BR] AMORES, TUCANO, TOMATE / [EN] SMOKED, ARCANE, TOMATO

public static class Levels {
    public static readonly Level[][] LevelMatrix = new Level[][] {
        new Level[] {
            new Level(4, 6,
                new string[] { "ROXO", "BELO" },
                new string[] { "BEOR", "OOXL", "" }),
            new Level(4, 11,
                new string[] { "LEVE", "PENA", "VOAR" },
                new string[] { "ENER", "AVAE", "LPOV", "", "" }),
            new Level(6, 12,
                new string[] { "UTOPIA", "FUTURO" },
                new string[] { "OAUTOF", "RIPUTU", "", "" }),
            new Level(5, 12,
                new string[] { "VAPOR", "DOBRA" },
                new string[] { "AROPR", "BDOVA", "", "" }),
            new Level(5, 10,
                new string[] { "MATIZ", "CORES" },
                new string[] { "SIEAO", "ZTRCM", "", "" }),
            new Level(5, 14,
                new string[] { "TARDE", "PRAIA", "BLOCO" },
                new string[] { "PALBT", "EOCIA", "DAROR", "", "" }),
            new Level(5, 14,
                new string[] { "VINDO", "CRINA", "PINTA" },
                new string[] { "PIRVC", "OTNNN", "AADII", "", "" }),
            new Level(6, 17,
                new string[] { "TIMBRE", "MUSEUS", "CABANA" },
                new string[] { "CRMBMT", "ASUNAB", "AEESUI", "", "" }),
            new Level(6, 15,
                new string[] { "SERENO", "CABELO", "ANTENA" },
                new string[] { "ANTLBS", "AOEEEE", "ONNRAC", "", "" }),
            new Level(6, 18,
                new string[] { "AMORES", "TUCANO", "TOMATE" },
                new string[] { "NECMTA", "ETMOAR", "AOSTUO", "", "" }),
        },
        new Level[] {
            new Level(4, 6,
                new string[] { "AURA", "IDEA" },
                new string[] { "IDUA", "AARE", "" }),
            new Level(4, 11,
                new string[] { "EVEN", "MEGA", "YEAR" },
                new string[] { "NAVA", "REGE", "EYEM", "", "" }),
            new Level(6, 12,
                new string[] { "UTOPIA", "FUTURE" },
                new string[] { "EAUTOF", "RIPUTU", "", "" }),
            new Level(5, 12,
                new string[] { "VAPOR", "BOARD" },
                new string[] { "DROPR", "ABOVA", "", "" }),
            new Level(5, 10,
                new string[] { "MAGIC", "COLOR" },
                new string[] { "CRGLO", "IOAMC", "", "" }),
            new Level(5, 14,
                new string[] { "AFTER", "BEACH", "BLOCK" },
                new string[] { "BBTFA", "HKRCC", "AOLEE", "", "" }),
            new Level(5, 14,
                new string[] { "WINDY", "DRINK", "PAINT" },
                new string[] { "WARDP", "TDIII", "YKNNN", "", "" }),
            new Level(6, 19,
                new string[] { "SYMBOL", "MUZZLE", "BANANA" },
                new string[] { "BAYASM", "ELLZZM", "OUNNBA", "", "" }),
            new Level(6, 17,
                new string[] { "SEREST", "GAZEBO", "ANTHEM" },
                new string[] { "AEARGE", "MOETHS", "BTNZSE", "", "" }),
            new Level(6, 17,
                new string[] { "SMOKED", "ARCANE", "TOMATO" },
                new string[] { "TACRSA", "DEEOOO", "KNTAMM", "", "" }),
        }
    };
}