import { useEffect, useState } from 'react';
import { getRecords, updateRecord } from '../api/services';
import { useNavigate, useParams } from "react-router-dom";

export function Edit() {
    const { id } = useParams();
    const [formValues, setFormValues] = useState({});
    const navigate = useNavigate();

    useEffect(() => {
        if (id) {
            getRecords(id).then(response => setFormValues(response.data.filter(item => item.Id === id)[0]));
        }
    }, [id]);

    const onFormSubmit = async (e) => {
        e.preventDefault();
        await updateRecord(formValues);
        navigate('/home');
    };

    return (
        <div className='container'>
            <form onSubmit={onFormSubmit} className="form">
                <div className="form-group">
                    <label>Enter surname: </label>
                    <input className="form-control" defaultValue={formValues.Surname} onChange={e => setFormValues({ ...formValues, surname: e.target.value })} type='text' />
                </div>

                <div className="form-group">
                    <label>Enter phone: </label>
                    <input className="form-control" defaultValue={formValues.Phone} onChange={e => setFormValues({ ...formValues, phone: e.target.value })} type='text' value={formValues.Phone} />
                </div>

                <input className="btn btn-primary" type="submit" value="Send" />
            </form>
        </div>
    );
}