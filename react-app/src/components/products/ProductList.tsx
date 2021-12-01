import { observer } from 'mobx-react-lite';
import React, { useEffect , useState } from 'react'
import { Container, Content, Table , Pagination } from 'rsuite'
import { useStore } from '../../stores/store';

export default observer(function ProductList(){

    const { productStore } = useStore();
    const { loading , products , getProducts , setOrderBy } = productStore;
    const [ sortType , setSortType ] = useState<any>();
    const [ sortColumn , setSortColumn ] = useState< string | undefined >();

    useEffect(() => {
        getProducts();
    }, [])

    const handleSortColumn = (sortColumn: React.SetStateAction<string | undefined>, sortType: React.SetStateAction<any>) => {
          setSortColumn(sortColumn);
          setSortType(sortType);       
          const orderBy = sortColumn + ' ' + sortType.toString();
          setOrderBy(orderBy);
    };

    const handleChangeLimit = (dataKey : any ) => {

    };

    return (
        <Container>
            <Content>
                <Table
                    height={420}
                    data={products}
                    loading={loading}
                    sortColumn={sortColumn}
                    sortType={sortType}
                    onSortColumn={handleSortColumn}
                    onRowClick={data => {
                        console.log(data);
                    }}
                >
                    <Table.Column width={170} align="center" fixed sortable>
                        <Table.HeaderCell>Id</Table.HeaderCell>
                        <Table.Cell dataKey="id" />
                    </Table.Column>

                    <Table.Column width={170} align="center" fixed sortable>
                        <Table.HeaderCell>Nazwa</Table.HeaderCell>
                        <Table.Cell dataKey="name" />
                    </Table.Column>

                    <Table.Column width={170} align="center" fixed sortable>
                        <Table.HeaderCell>Kategoria</Table.HeaderCell>
                        <Table.Cell dataKey="categoryName" />
                    </Table.Column>

                    <Table.Column width={170} align="center" fixed sortable>
                        <Table.HeaderCell>Producent</Table.HeaderCell>
                        <Table.Cell dataKey="producerName" />
                    </Table.Column>

                    <Table.Column width={170} align="center" fixed sortable>
                        <Table.HeaderCell>Data utworzenia</Table.HeaderCell>
                        <Table.Cell dataKey="createdAt" />
                    </Table.Column>

                    <Table.Column width={170} align="center" fixed sortable>
                        <Table.HeaderCell>Utworzone przez</Table.HeaderCell>
                        <Table.Cell dataKey="createdBy" />
                    </Table.Column>

                    <Table.Column width={170} align="center" fixed sortable>
                        <Table.HeaderCell>Data aktualizacji</Table.HeaderCell>
                        <Table.Cell dataKey="updatedAt" />
                    </Table.Column>

                    <Table.Column width={170} align="center" fixed sortable>
                        <Table.HeaderCell>Zaaktualizowany przez</Table.HeaderCell>
                        <Table.Cell dataKey="updatedBy" />
                    </Table.Column>

                </Table>
                <div style={{padding: 20}}> 
                    <Pagination
                        prev
                        next
                        first
                        last
                        size="xs"
                        layout={['total', '-', 'limit', '|', 'pager' , 'skip']}
                        total={150}
                        limitOptions={[10, 20]}
                        limit={10}
                    />                  
                </div>
            </Content>
        </Container>
    )
})