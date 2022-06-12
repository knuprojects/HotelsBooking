import React, { useEffect, useState } from 'react';
import './Home.css'

export const Home = () => {
  const [posts, setPosts] = useState([]);

  useEffect(() => {
    fetch('https://localhost:44336/api/Hotel/getallhotels')
      .then((response) => response.json())
      .then((json) => setPosts(json));
  });


  return (
    <div>
        <ul className="hotel__container">
            {posts.map(post => (
                <li className="hotel__element" key={post.id}>
                    <span className="hotel__name">{post.name.value}</span>
                    <span className="hotel__description">{post.description.value}</span>
                    <span className="hotel__city">{post.city.value}</span>
                    <img className="hotel__photo" src={post.photoUrl.value}/>
                </li>
            ))}
        </ul>
    </div>
  );
};

export default Home