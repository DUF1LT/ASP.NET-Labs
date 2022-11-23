import { useState } from 'react';
import { addRecord } from '../api/services';
import { useNavigate } from "react-router-dom";

export function Add() {
    const [formValues, setFormValues] = useState({});
    const navigate = useNavigate();

    const onFormSubmit = async (e) => {
        e.preventDefault();
        await addRecord(formValues);
        navigate('/home');
    };

    return (
        <div className='container'>
            <form onSubmit={onFormSubmit} className="form">
                <div className="form-group">
                    <label>Enter surname: </label>
                    <input className="form-control" onChange={e => setFormValues({ ...formValues, surname: e.target.value })} type='text' />
                </div>

                <div className="form-group">
                    <label>Enter phone: </label>
                    <input className="form-control" onChange={e => setFormValues({ ...formValues, phone: e.target.value })} type='text' />
                </div>

                <input className="btn btn-primary" type="submit" value="Send" />
            </form>
        </div>
    );
}