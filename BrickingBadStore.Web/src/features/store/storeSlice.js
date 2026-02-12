import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import api from '../../api/axios';

// Async thunk to fetch the store with all data
export const fetchStore = createAsyncThunk(
  'store/fetchStore',
  async (_, { rejectWithValue }) => {
    try {
      const response = await api.get('/Store');
      return response.data;
    } catch (error) {
      return rejectWithValue(error.response?.data || 'Failed to fetch store');
    }
  }
);

// Async thunk to create a container
export const createContainer = createAsyncThunk(
  'store/createContainer',
  async (containerData, { rejectWithValue }) => {
    try {
      const response = await api.post('/Containers', containerData);
      return response.data;
    } catch (error) {
      return rejectWithValue(error.response?.data || 'Failed to create container');
    }
  }
);

// Async thunk to update a container
export const updateContainer = createAsyncThunk(
  'store/updateContainer',
  async ({ id, ...containerData }, { rejectWithValue }) => {
    try {
      await api.put(`/Containers/${id}`, containerData);
      return { id, ...containerData };
    } catch (error) {
      return rejectWithValue(error.response?.data || 'Failed to update container');
    }
  }
);

// Async thunk to delete a container
export const deleteContainer = createAsyncThunk(
  'store/deleteContainer',
  async (id, { rejectWithValue }) => {
    try {
      await api.delete(`/Containers/${id}`);
      return id;
    } catch (error) {
      return rejectWithValue(error.response?.data || 'Failed to delete container');
    }
  }
);

const storeSlice = createSlice({
  name: 'store',
  initialState: {
    data: null,
    loading: false,
    error: null,
  },
  reducers: {},
  extraReducers: (builder) => {
    builder
      // Fetch Store
      .addCase(fetchStore.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(fetchStore.fulfilled, (state, action) => {
        state.loading = false;
        state.data = action.payload;
      })
      .addCase(fetchStore.rejected, (state, action) => {
        state.loading = false;
        state.error = action.payload;
      })
      // Create Container
      .addCase(createContainer.fulfilled, (state, action) => {
        // Optionally update state optimistically
        // For simplicity, we'll just refetch the store after mutations
      })
      // Update Container
      .addCase(updateContainer.fulfilled, (state, action) => {
        // Optionally update state optimistically
      })
      // Delete Container
      .addCase(deleteContainer.fulfilled, (state, action) => {
        // Optionally update state optimistically
      });
  },
});

export default storeSlice.reducer;
