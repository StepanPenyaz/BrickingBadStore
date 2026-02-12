import { configureStore } from '@reduxjs/toolkit';
import storeReducer from '../features/store/storeSlice';

export const store = configureStore({
  reducer: {
    store: storeReducer,
  },
});
