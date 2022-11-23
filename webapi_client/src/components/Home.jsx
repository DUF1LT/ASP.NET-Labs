import { useState, useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import { deleteRecord, getRecords } from "../api/services";

export function Home() {
    const [data, setData] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        getRecords().then(response => setData(response.data));
    }, []);

    const onDeleteClick = async (id) => {
        await deleteRecord(id);
        setData(data.filter(item => item.Id !== id));
        navigate('/home');
    };

    return (
        <div className='App'>
            <table className="table">
                <thead>
                    <tr>
                        <th scope="col">Surname</th>
                        <th scope="col">Phone</th>
                        <th scope="col">Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {data
                        ? data.map(item => (
                            <tr key={item.Id}>
                                <td>{item.Surname}</td>
                                <td>{item.Phone}</td>
                                <td><Link to={`edit/${item.Id}`}>Edit</Link> | <Link onClick={() => onDeleteClick(item.Id)}>Delete</Link></td>
                            </tr>
                        ))
                        : (
                            <tr>
                                <td class="text-center" colspan="3"><h3>There are no records in dictionary yet!</h3></td>
                            </tr>
                        )}
                </tbody>
            </table>
        </div>
    );
}