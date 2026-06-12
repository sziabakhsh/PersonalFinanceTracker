import api from './api'


export interface CategoryRequest {
  name: string;
  type: string;
}

export interface CategoryDto {
  name: string;
  type: string;
}

export const createCategory = async (request: CategoryRequest):
Promise<CategoryDto>=>{
    const response = await api.post<CategoryDto>(
        "category/create",
        request
    )
    return response.data;
};

// getCategories()

// getCategory(id)

// updateCategory()

// deleteCategory()