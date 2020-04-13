export interface Country {
    name: string;
    alpha2Code: string;
    flag: string;
    languages: Language[]
}

export interface Language {
  iso639_1: string
}
