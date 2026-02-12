import React, { useState, useEffect } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { fetchStore } from '../features/store/storeSlice';
import Cabinet from './Cabinet';

const Store = () => {
  const dispatch = useDispatch();
  const { data: store, loading, error } = useSelector((state) => state.store);
  const [activeTab, setActiveTab] = useState(0);

  useEffect(() => {
    dispatch(fetchStore());
  }, [dispatch]);

  if (loading) {
    return <div style={{ padding: '20px', fontSize: '18px' }}>Loading...</div>;
  }

  if (error) {
    return <div style={{ padding: '20px', color: 'red' }}>Error: {error}</div>;
  }

  if (!store || !store.cabinets || store.cabinets.length === 0) {
    return <div style={{ padding: '20px' }}>No data available</div>;
  }

  return (
    <div style={{ padding: '20px' }}>
      <h1>{store.name}</h1>
      
      {/* Tabs Navigation */}
      <div
        style={{
          display: 'flex',
          borderBottom: '2px solid #ddd',
          marginBottom: '20px',
        }}
      >
        {store.cabinets.map((cabinet, index) => (
          <button
            key={cabinet.id}
            onClick={() => setActiveTab(index)}
            style={{
              padding: '10px 20px',
              cursor: 'pointer',
              border: 'none',
              borderBottom: activeTab === index ? '3px solid #007bff' : 'none',
              backgroundColor: activeTab === index ? '#f0f8ff' : 'transparent',
              fontWeight: activeTab === index ? 'bold' : 'normal',
              fontSize: '16px',
            }}
          >
            {cabinet.name}
          </button>
        ))}
      </div>

      {/* Active Cabinet Content */}
      {store.cabinets[activeTab] && (
        <Cabinet cabinet={store.cabinets[activeTab]} />
      )}
    </div>
  );
};

export default Store;
