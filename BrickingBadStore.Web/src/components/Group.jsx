import React from 'react';
import Container from './Container';

const Group = ({ group }) => {
  return (
    <div
      style={{
        border: '3px solid #333',
        padding: '15px',
        margin: '10px',
        borderRadius: '5px',
      }}
    >
      <h3 style={{ margin: '0 0 10px 0' }}>{group.name}</h3>
      <div
        style={{
          display: 'flex',
          flexWrap: 'wrap',
          gap: '10px',
        }}
      >
        {group.containers.map((container) => (
          <Container key={container.id} container={container} />
        ))}
      </div>
    </div>
  );
};

export default Group;
