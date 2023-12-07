import { useState, useEffect } from 'react';
import axios from 'axios';

const App = () => {

    const [productos, setProductos] = useState([])

    useEffect(() => {
        const traerProductos = async () => {
            const resp = await axios.get('/api/productos/GetProductos')
            setProductos(resp.data)
        }
        traerProductos()
    }, [])

    return (
        <div className="container">
            <h1>Productos</h1>
            <div className="row">
                <div className="col-sm-12">
                    <table className="table table-striped">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>Marca</th>
                                <th>Precio</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                productos.map(producto => (
                                    <tr key={producto.idProducto}>
                                        <td>{producto.idProducto}</td>
                                        <td>{producto.marca}</td>
                                        <td>{producto.precio}</td>
                                    </tr>
                                ))
                            }
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    )

    return (<div></div>)
}
export default App