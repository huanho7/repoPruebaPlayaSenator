import { CharacteristicDto } from "./CharacteristicDto";

export interface HotelDto {
    id: number;
    name: string;
    description: string;
    idCategory: number;
    categoryName: string;
    idCity: number;
    cityName: string;
    idRelevance: number; // Destacado u otros
    relevanceName: string;
    shortImageTitle: string;
    shortImageData: string;
    largeImageTitle: string;
    largeImageData: string;     

    listaCaracteristicas:CharacteristicDto[];
  }