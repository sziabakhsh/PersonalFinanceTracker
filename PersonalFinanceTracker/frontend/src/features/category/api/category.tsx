import api from '../../../Shared/api/api'


export interface CategoryRequest {
  name: string;
  type: string;
}

export interface CategoryDto {
  name: string;
  type: string;
}

export const createCategory = async (
  request: CategoryRequest
): Promise<CategoryDto> => {

  const { data } = await api.post<CategoryDto>(
    `category/create`,
    request
  );

  return data;
};

export const getCategories = async (): Promise<CategoryDto[]> => {
  const { data } = await api.get<CategoryDto[]>(
    `category`
  );

  return data;
};

export const getCategory = async (
  id: string
): Promise<CategoryDto> => {
  const { data } =
    await api.get<CategoryDto>(
      `category/${id}`
    );

  return data;
};

// updateCategory()

// deleteCategory()