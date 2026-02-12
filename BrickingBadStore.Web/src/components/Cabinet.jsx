import React from 'react';
import Group from './Group';

const Cabinet = ({ cabinet }) => {
  return (
    <div style={{ padding: '20px' }}>
      <h2>{cabinet.name}</h2>
      <div>
        {cabinet.groups.map((group) => (
          <Group key={group.id} group={group} />
        ))}
      </div>
    </div>
  );
};

export default Cabinet;
