import axios from "axios";

export const client = axios.create({ baseURL: 'http://localhost:5000/api/dict' });

export const getRecords = () => client.get();

export const addRecord = (entry) => client.post('', entry)

export const updateRecord = (entry) => client.put('', entry)

export const deleteRecord = (id) => client.delete(`${id}`)