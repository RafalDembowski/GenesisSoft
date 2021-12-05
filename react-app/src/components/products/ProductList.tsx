import { observer } from 'mobx-react-lite';
import React, { useEffect , useState } from 'react'
import { Container, Content, Table , Pagination } from 'rsuite'
import { PagingParams } from '../../models/pagination';
import { useStore } from '../../stores/store';
import { useNavigate } from 'react-router-dom';

export default observer(function ProductList(){

    const navigate = useNavigate();
    const { productStore } = useStore();
    const { loading , products , pagination , getProducts , setOrderBy , setPagingParams , pagingParams } = productStore;
    const [ sortType , setSortType ] = useState<any>();
    const [ sortColumn , setSortColumn ] = useState< string | undefined >();
    const [ page , setPage ] = useState<number>(1);

    useEffect(() => {
        getProducts();
    }, [])

    const handleSortColumn = (sortColumn: React.SetStateAction<string | undefined>, sortType: React.SetStateAction<any>) => {
          setSortColumn(sortColumn);
          setSortType(sortType);       
          const orderBy = sortColumn + ' ' + sortType.toString();
          setOrderBy(orderBy);
    };

    const handleChangePage = (page : number) => {
        const newPagingParams = new PagingParams(page , pagingParams.pageSize);
        setPage(page);
        setPagingParams(newPagingParams);
    }

    const handleChangeLimit = (dataKey : any ) => {
        const newPagingParams = new PagingParams(pagingParams.currentPage , dataKey);
        setPagingParams(newPagingParams);
    };

    const handleClick = (data : any) => {
        let product = JSON.parse(JSON.stringify(data))
        navigate(product.id);
    }

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
                    onRowClick={handleClick}
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
                { (pagination) &&
                <div style={{padding: 20}}> 
                    <Pagination
                        prev
                        next
                        first
                        last
                        size="xs"
                        layout={['total', '-', 'limit' ,'|', 'pager']}
                        total={pagination!.totalCount}
                        limit={pagination!.pageSize}
                        limitOptions={[10, 20]}
                        activePage={page}
                        onChangePage={handleChangePage}
                        onChangeLimit={handleChangeLimit}
                    />                  
                </div>
                }
                
            </Content>
                
        </Container>
    )
})