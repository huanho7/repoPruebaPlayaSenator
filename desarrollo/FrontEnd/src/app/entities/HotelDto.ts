export interface HotelDto {
    Id: number;
    Name: string;
    Description: string;
    IdCategory: number;
    CategoryName: string;
    IdCity: number;
    CityName: string;
    IdRelevance: number; // Destacado u otros
    RelevanceName: string;
    ShortImageTitle: string;
    ShortImageData: string;
    LargeImageTitle: string;
    LargeImageData: string;     
  }