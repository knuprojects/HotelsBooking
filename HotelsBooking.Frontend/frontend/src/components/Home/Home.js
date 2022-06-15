import React, { useEffect, useState } from 'react';
import './Home.css'

export const Home = () => {
  const [posts, setPosts] = useState([]);

  useEffect(() => {
    fetch('https://localhost:44336/api/Hotel/getallhotels')
      .then((response) => response.json())
      .then((json) => setPosts(json));
  });

  const [value, setValue] = useState('');

  const filterByCity = posts.filter(post => {
    return post.city.value.toLowerCase().includes(value.toLowerCase())
  })

  return (
    <div>
      <input
        type="text"
        placeholder="City"
        className="search__input"
        onChange={(event) => setValue(event.target.value)}/>
        <ul className="hotel__container">
            {filterByCity.map(post => (
                <li className="hotel__element" key={post.id}>
                    <span className="hotel__name">{post.name.value}</span>
                    <span className="hotel__description">{post.description.value}</span>
                    <span className="hotel__city">{post.city.value}</span>
                    <img className="hotel__photo" src={post.photoUrl.value} alt=''/>
                    <button className="hotel__button">Click me</button>
                </li>
            ))}
        </ul>
    </div>
  );
};

export default Home