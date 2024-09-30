using System;
using System.Collections.Generic;
using WatchingOrchestrator.Dto;
using WatchingOrchestrator.Models;

namespace WatchingOrchestrator.Profiles
{
    public class CustomMapper : ICustomMapper
    {
        #region Model -> Dto
         public List<ContentsDto> fromContentsToContentsDto(List<Contents> contents) {
            try {
                List<ContentsDto> contentsDtos = new List<ContentsDto>();
                if (contents != null) {
                    contents.ForEach(
                        content => contentsDtos.Add(
                            new ContentsDto(
                                content.ContentsId,
                                content.ContentsType,
                                fromElementsToElementsDto(content.ElementsList))
                        )
                    );
                }

                return contentsDtos;
            }
            catch(Exception ex) {
                throw new ArgumentException($"Errore nella conversione da ContentsDto -> Contents. Message {ex.Message}");
            }   
        }

        public List<ElementsDto> fromElementsToElementsDto(List<Elements> elemements)
        {
            try
            {
                List<ElementsDto> elementsDto = new List<ElementsDto>();
                if (elemements!= null)
                {
                    elemements.ForEach(
                        elemement => elementsDto.Add(
                            new ElementsDto(
                                elemement.ElementsId,
                                elemement.ReleaseDate,
                                elemement.Title,
                                elemement.Description,
                                elemement.Immage,
                                elemement.FlagPiaciuto)
                        )
                    );
                }
                return elementsDto;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Errore nella conversione da ElementsDto -> Elements. Message {ex.Message}");
            }
        }

    }
    #endregion
}
