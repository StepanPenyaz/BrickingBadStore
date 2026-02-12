import React from 'react';

const Container = ({ container }) => {
  return (
    <div
      style={{
        width: '80px',
        height: '80px',
        border: '1px solid #ccc',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        backgroundColor: '#f9f9f9',
        fontSize: '14px',
        fontWeight: 'bold',
      }}
    >
      {container.id}
    </div>
  );
};

export default Container;
